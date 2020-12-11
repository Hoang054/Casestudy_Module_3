var Suppliers = Suppliers || {};
var count = document.getElementById("count1").value;

Suppliers.delete = function (id) {
    
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa Supplier này không?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Không'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Có'
            }
        },
        callback: function (result) {
            if (count == 0) {
                $.ajax({
                    url: `/Product/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data.deleSupplier > 0) {
                            console.log(count);
                        }
                    }
                });
            }
            else {
                bootbox.alert('Supplier has product! cannot delete');
            }
        }
    });
}

$(document).ready(function () {
    $("#tbList").dataTable();
});