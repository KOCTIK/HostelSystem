Ext.define("MyExtGenApp.shared.util.Date", {
  singleton: true,
  DDMMYYYY: function (value, record) {
    return Ext.Date.format(new Date(value), "d-m-Y");
  },
}); 