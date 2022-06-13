// Call the dataTables jQuery plugin
$(document).ready(function() {
    $('#dataTable').DataTable();
    $('AlertBox').removeClass('hide');
    $$('AlertBox').delay(1000).slideUp(500);
});
