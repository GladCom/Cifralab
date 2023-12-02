const fieldsArr = [
    {
      label: "Name",
      name: "name",
      validation: e => {
        const name = e.target.value;
        if (name.length > 6) {
          return false;
        } else {
          return true;
        }
      },
      error: "Enter a good name"
    },
    {
      label: "Age",
      name: "age",
      validation: e => {
        const name = e.target.value;
        if (name.length > 6) {
          return false;
        } else {
          return true;
        }
      },
      error: "Haha"
    },
    {
      label: "RelationShip",
      selectMessage: "Select",
      name: "relationShip",
      type: "select",
      options: [
        { label: "None", value: "" },
        { label: "Single", value: "single" },
        { label: "Haq se Single", value: "haqSeSingle" }
      ],
      validation: (e, a) => {
        const name = e.target.value;
        if (name.length > 6) {
          return false;
        } else {
          return true;
        }
      },
      error: "go home kid"
    }
  ];
  
  export default fieldsArr;
  