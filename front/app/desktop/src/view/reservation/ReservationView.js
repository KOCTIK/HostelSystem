Ext.define("MyExtGenApp.view.reservation.ReservatinView", {
  extend: "Ext.grid.Grid",
  xtype: "reservationview",
  cls: "reservationview",
  store: { type: "reservationApi" },
  columns: [
    {
      text: "Created",
      dataIndex: "creationDate",
      cell: { renderer: MyExtGenApp.shared.util.Date.DDMMYYYY },
      flex: 1,
    },
    {
      text: "Check In",
      dataIndex: "checkInDate",
      cell: { renderer: MyExtGenApp.shared.util.Date.DDMMYYYY },
      flex: 1,
    },
    {
      text: "Check Out",
      dataIndex: "checkOutDate",
      cell: { renderer: MyExtGenApp.shared.util.Date.DDMMYYYY },
      flex: 1,
    },
    { text: "Code", dataIndex: "reservationCode", flex: 1 },
    { text: "Price", dataIndex: "price", flex: 1 },
  ],
});
