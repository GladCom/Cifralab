import path from 'path';
import { fileURLToPath } from 'url';
import HtmlWebpackPlugin from 'html-webpack-plugin';
import { CleanWebpackPlugin } from 'clean-webpack-plugin';
import TsconfigPathsPlugin from 'tsconfig-paths-webpack-plugin';
import { config } from 'dotenv';
import webpack from 'webpack';
import CopyWebpackPlugin from 'copy-webpack-plugin';

config();

// Получаем __dirname в ES модулях
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const projectRoot = process.cwd();

export default (env, argv) => {
  const isProduction = argv.mode === 'production';

  return {
    entry: './src/index.tsx',
    output: {
      path: path.resolve(__dirname, 'distWebpack'),
      filename: 'bundle.[contenthash].js',
      publicPath: '/',
    },
    resolve: {
      extensions: ['.tsx', '.ts', '.js', '.jsx'],
      plugins: [
        new TsconfigPathsPlugin(), // Автоматически подтянет алиасы из tsconfig.json
      ],
    },
    module: {
      rules: [
        {
          test: /\.(ts|tsx|js|jsx)$/,
          exclude: /node_modules/,
          use: [
            {
              loader: 'ts-loader',
              options: {
                //  Настройка, влияющие на плавный переход проекта с JS на TS
                //  Если ее вырубить, проект с ошибками не будет собираться
                //transpileOnly: true, // Ускоряет сборку, но игнорирует проверку типов при сборке, включить при полном переходе на TS
                compilerOptions: {
                  noEmit: false, // Важно для генерации вывода
                  //  Настройка, влияющие на плавный переход проекта с JS на TS
                  noEmitOnError: false      // СБОРКА НЕ ПАДАЕТ ПРИ ОШИБКАХ TS
                },
              },
            },
          ],
        },
        {
          test: /\.css$/i,
          use: [
            'style-loader',
            'css-loader',
            {
              loader: 'postcss-loader',
              options: {
                postcssOptions: {
                  config: path.resolve(__dirname, 'postcss.config.cjs'),
                },
              },
            },
          ],
        },

        // Обработка CSS модулей (только ваши модульные стили)
        {
          test: /\.module\.css$/,
          exclude: path.resolve(__dirname, 'node_modules'),
          use: [
            'style-loader',
            {
              loader: 'css-loader',
              options: {
                modules: {
                  auto: true,
                  localIdentName: isProduction
                    ? '[hash:base64]'
                    : '[path][name]__[local]--[hash:base64:5]',
                },
              },
            },
            'postcss-loader',
          ],
        },

        // Обработка SCSS (глобальные стили)
        {
          test: /\.scss$/,
          include: [path.resolve(__dirname, 'node_modules'), path.resolve(__dirname, 'src/styles')],
          use: ['style-loader', 'css-loader', 'postcss-loader', 'sass-loader'],
        },

        // Обработка SCSS модулей
        {
          test: /\.module\.scss$/,
          exclude: path.resolve(__dirname, 'node_modules'),
          use: [
            'style-loader',
            {
              loader: 'css-loader',
              options: {
                modules: {
                  auto: true,
                  localIdentName: isProduction
                    ? '[hash:base64]'
                    : '[path][name]__[local]--[hash:base64:5]',
                },
              },
            },
            'postcss-loader',
            'sass-loader',
          ],
        },
        {
          test: /\.(png|svg|jpg|jpeg|gif)$/i,
          type: 'asset/resource',
        },
        {
          test: /\.(woff|woff2|eot|ttf|otf)$/i,
          type: 'asset/resource',
        },
        {
          test: /\.svg$/,
          use: ['@svgr/webpack', 'file-loader'],
        },
      ],
    },
    plugins: [
      new CleanWebpackPlugin(),
      new HtmlWebpackPlugin({
        template: './index.html',
        favicon: './src/assets/favicon.ico',
      }),
      new CopyWebpackPlugin({
        patterns: [
          {
            from: path.join(projectRoot, 'public/manifest.json'),
            to: 'manifest.json',
          },
        ],
      }),
      new webpack.DefinePlugin({
        'process.env.REACT_APP_API_URL': JSON.stringify(process.env.REACT_APP_API_URL),
        'process.env.NODE_ENV': JSON.stringify(isProduction ? 'production' : 'development'),
      }),
    ],
    devServer: {
      static: {
        directory: path.join(__dirname, 'distWebpack'),
      },
      historyApiFallback: true,
      compress: true,
      port: 3000,
      hot: true,
      open: true,
    },
    devtool: isProduction ? 'source-map' : 'eval-source-map',
  };
};
