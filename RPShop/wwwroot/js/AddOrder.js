
var itemsList = [];
document.getElementById('date').valueAsDate = new Date();
$(function () {
    $("#add").click(function () {
        var isValid = true;
        var item = {
            productid: $('#productsItems').val(),
            Price: +$('#price').val(),
            Quantity: +$('#quantity').val(),
            TotalPrice: $('#price').val() * $('#quantity').val(),
            name: name

        }
        
        if (document.getElementById("productsItems").selectedIndex == 0) {
            $('#productsItems').siblings('span.error').text('Please select item');
            isValid = false;
        }
        else {
            $('#productsItems').siblings('span.error').text('');
        }
        if (!($("#quantity").val().trim() != '' )) {
            $('#quantity').siblings('span.error').text('Please enter quantity');
            isValid = false;
        }
        if (+$("#quantity").val() > +$("#remain").val() || +$("#quantity").val() <= 0 ){
            $('#quantity').siblings('span.error').text('Please enter quantity <= remaining');
            isValid = false;
        }
        else {
            $('#quantity').siblings('span.error').text('');
        }
        if (isValid) {
            itemsList.push(item);
            drawTable();
        }
        $('#price').val('');
        $('#quantity').val('');
        $('#total').val('');
    });

    $("#OrderItems").on("click", ".remove", function () {
        $(this).parents("tr").remove();
    });
    
    $("#submit").click(function () {
        var isValid = true;
        //$("#OrderItems tr").each(function () {
        //    var item = {
        //        productid: $('#productsItems').val(),
        //        Price: $('#price').val(),
        //        Quantity: $('#quantity').val(),
        //        TotalPrice: $('#total').val(),
        //        name: name,
        //    }
        //    console.log(item);
        //    itemsList.push(item);
        //});
        //return false;
        if (itemsList.length == 0) {
            $('#orderMessage').text('Please add items !');
            isValid = false;
        }
        else {
            $('#orderMessage').text('Complete add');
        }
        
        console.log(itemsList);
        if (isValid) {
            
            debugger;
            $("#submit").attr("disabled", true);
            $("#submit").html('Please wait...');
            let orderPrint = {
                Date: $("#date").val(),
                Items: itemsList
            };
            console.log(JSON.stringify(orderPrint));
            $.ajax({
                type: 'POST',
                url: '/Oder/AddOrderAndOrderDetails',
                //dataType: 'json',
                //data: {
                //    Date: $("#date").val(),
                //    Items: itemsList
                //},
                //dataType: 'JSON',
                //contentType: "application/json",
                data: orderPrint,
                success: function (data) {
                    debugger;
                    if (data == true) {
                        window.location.href = "/Oder/OrderCustomer";
                        $('#orderMessage').text(data.message);
                    }
                    else {
                        $('#orderMessage').text(data);
                    }
                }
            })
        }
    });
    
});

drawTable = function () {
    document.getElementById('OrderItems').innerHTML = "<tr><th>ProductName</th><th>Price</th><th>Quantity</th><th>Total</th></tr>";
    for (let i = 0; i < itemsList.length; i++) {
        let tam = itemsList[i].Price * itemsList[i].Quantity;
        let str = `<tr><td>${itemsList[i].name}</td><td>${itemsList[i].Quantity}</td><td>${itemsList[i].Price}</td>
<td>${tam}</td><td><button type='button' onclick='removeOrderDetails(${i})'>Remove</button></td></tr>`;
        document.getElementById('OrderItems').innerHTML += str;
    }
}

removeOrderDetails = function (index) {
    itemsList.splice(index, 1);
    drawTable();
}



        //if (isValid) {
        //    var total = parseInt($('#quantity').val()) * parseFloat($('#price').val());

        //    $("#total").val(total);
        //    var tru = parseInt($('#remain').val()) - parseFloat($('#quantity').val());
        //    $("#remain").val(tru);

        //    var ProductId = document.getElementById('productsItems').value;




        //    var $newRow = $("#MainRow").clone().removeAttr('id');

        //    $('#productsItems', $newRow).val(ProductId);

        //    $('#add', $newRow).addClass('remove').html('<span class=\"fa fa-minus-circle\"></span> Remove').removeClass('btn-success').addClass("btn-danger");

        //    $("#productsItems, #quantity", $newRow).attr('disabled', true);

        //    $("#productsItems, #quantity, #price, #total", $newRow).removeAttr('id');

        //    $("span.error", $newRow).remove();

        //    $("#OrderItems").append($newRow[0]);

        //    document.getElementById("productsItems").selectedIndex = 0;
        //    $('#price').val();
        //    $('#quantity').val();
        //    $('#total').val();
        //}