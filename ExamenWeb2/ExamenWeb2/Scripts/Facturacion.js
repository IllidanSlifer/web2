$(document).on("ready", function () {

    $('#btnSearch').on('click', function () {
        GetFacturacionById($('#txtIdSearch').val());
    });
 
    $('#btnCreate').on('click', function () {
        var Facturacion = new Object();
        Facturacion.Id = $('#txtIdSearch').val();
        Facturacion.MontoTotal = $('#txtMontoTotal').val();
        Facturacion.SubTotal = $('#txtSubTotal').val();
        Facturacion.Detalle = $('#txtDetalle').val();
        CreateFacturacion(JSON.stringify(Facturacion));
    });
    
    GetAll();

})

function GetAll() {

    var item = "";
    $('#tblList tbody').html('');
    $.getJSON('/api/Facturacion', function (data) {
        $.each(data, function (key, value) {
            item += "<tr><td>" + value.Id + "</td><td>" + value.MontoTotal + "</td><td>" + value.SubTotal + "</td><td>"
            + value.Detalle + "</td><td>";
        });
        $('#tblList tbody').append(item);
    });
};

//function GetFacturacionById(IdFacturacion) {
//    var url = '/api/Inventario/' + IdFacturacion;
//    $.getJSON(url)
//        .done(function (data) {
//            $('#txtId').val(data.Id);
//            $('#txtMontoTotal').val(data.MontoTotal);
//            $('#txtSubTotal').val(data.SubTotal);
//            $('#txtDetalle').val(data.Detalle);
//        })
//        .fail(function (erro) {
//            ClearForm();
//        });
//};
function CreateFacturacion(Facturacion) {
    var url = '/api/Facturacion/';
    $.ajax({
        url: url,
        type: 'POST',
        data: Facturacion,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            201: function () {
                GetAll();
                ClearForm();
                alert('Facturacion with id: ' + IdFacturacion + ' fue actualizado');
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}
