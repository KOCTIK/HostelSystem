Ext.define("MyExtGenApp.store.ReservationApi", {
  extend: "Ext.data.Store",
  alias: "store.reservationApi",
  proxy: {
    type: "ajax",
    url: "http://localhost:5000/api/reservation",
  },
  autoLoad: true,
});
