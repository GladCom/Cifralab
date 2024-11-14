using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Win32;
using Students.DB.Converter.Model;
using Students.DB.Converter.Utilities;

namespace Students.DB.Converter.ViewModels;

/// <summary>
/// Модель для окна конвертера данных по студентам из excel в БД. 
/// </summary>
public class MainWindowViewModel : INotifyPropertyChanged
{
  #region Поля и свойства

  /// <summary>
  /// Имя файла Excel.
  /// </summary>
  private string? _fileName;

  /// <summary>
  /// Имя файла Excel.
  /// </summary>
  public string? FileName
  {
    get => this._fileName;
    set
    {
      if(value == this._fileName)
        return;

      this._fileName = value;
      this.OnPropertyChanged();
    }
  }

  /// <summary>
  /// Страница с данными тильды из файла.
  /// </summary>
  private Page? _tildaPage;

  /// <summary>
  /// Страница с данными тильды из файла.
  /// </summary>
  public Page? TildaPage
  {
    get => this._tildaPage;
    set
    {
      if(value == this._tildaPage)
        return;

      this._tildaPage = value;
      this.OnPropertyChanged();
    }
  }

  /// <summary>
  /// Страница с дополненными данными из файла.
  /// </summary>
  private Page? _dbPage;

  /// <summary>
  /// Страница с дополненными данными из файла.
  /// </summary>
  public Page? DbPage
  {
    get => this._dbPage;
    set
    {
      if(value == this._dbPage)
        return;

      this._dbPage = value;
      this.OnPropertyChanged();
    }
  }

  /// <summary>
  /// Список листов выбранного файла Excel.
  /// </summary>
  public ObservableCollection<Page> ListPage { get; } = new();

  /// <summary>
  /// Результат загрузки данных из файла (в том числе ошибки загрузки).
  /// </summary>
  public ObservableCollection<ConvertInformation> Messages { get; } = new();

  /// <summary>
  /// Список заявок, полученный из файла.
  /// </summary>
  public ObservableCollection<StudentWithRequest> ListRequest { get; } = new();

  /// <summary>
  /// Команда выбора файла.
  /// </summary>
  private ICommand? _selectFileCommand;

  /// <summary>
  /// Команда выбора файла.
  /// </summary>
  public ICommand SelectFileCommand => this._selectFileCommand ??= new RelayCommand(_ => { this.SelectFile(); });

  /// <summary>
  /// Команда загрузки данных из файла.
  /// </summary>
  private ICommand? _loadCommand;

  /// <summary>
  /// Команда загрузки данных из файла.
  /// </summary>
  public ICommand LoadCommand => this._loadCommand ??= new RelayCommand(_ => { this.LoadRequests(); },
      _ => this.TildaPage is not null && this.DbPage is not null && this.FileName is not null);

  /// <summary>
  /// Команда сохранения данных в БД.
  /// </summary>
  private ICommand? _saveCommand;

  /// <summary>
  /// Команда сохранения данных в БД.
  /// </summary>
  public ICommand SaveCommand => this._saveCommand ??= new RelayCommand(_ => { this.SaveToDb(); }
        , _ => this.ListRequest is { Count: > 0 });

  #endregion

  #region INotifyPropertyChanged

  public event PropertyChangedEventHandler? PropertyChanged;
  public void OnPropertyChanged([CallerMemberName] string prop = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
  }

  #endregion

  #region Методы

  /// <summary>
  /// Загрузить список страниц из файла.
  /// </summary>
  /// <param name="filename">Имя файла.</param>
  private void LoadPagesFromExcelFile(string filename)
  {
    Model.Converter.LoadPagesFromExcelFile(filename, this.ListPage);

    this.TildaPage = this.ListPage.FirstOrDefault(e => e.Name == "Лист1");
    this.DbPage = this.ListPage.FirstOrDefault(e => e.Name == "База данных (Excel)");
  }

  /// <summary>
  /// Выбрать файл эксель.
  /// </summary>
  private void SelectFile()
  {
    var dlg = new OpenFileDialog
    {
      DefaultExt = ".xlsx",
      Filter = "Excel Files (*.xlsx)|*.xlsx"
    };

    if(dlg.ShowDialog() != true)
      return;

    this.FileName = dlg.FileName;
    this.LoadPagesFromExcelFile(this.FileName);
  }

  /// <summary>
  /// Загрузить данные из файла эксель.
  /// </summary>
  private void LoadRequests()
  {
    Model.Converter.LoadInformation(this.FileName!, this.TildaPage, this.DbPage, this.ListRequest);
  }

  /// <summary>
  /// Сохранить загруженные данные в БД.
  /// </summary>
  private void SaveToDb()
  {
    Model.Converter.SaveToDb(this.ListRequest, this.Messages);
  }

  #endregion
}