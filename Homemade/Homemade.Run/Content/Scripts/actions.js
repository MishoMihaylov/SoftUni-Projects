//function addItem(productId) {
//    $.notify("Product added to cart!", "success");
//};

//function removeItem(productId) {
//    $.ajax({
//        url: "/Products/Remove?productId=" + productId,
//        method: "POST",
//        success: function (result) {
//            $.notify(result + " was deleted!", "error");

//        }
//    });
//};

function addItem(productId) {
    $.ajax({
        url: "/ShoppingCart/AddToCart?productId=" + productId,
        method: "POST",
        success: function (result) {
            $.notify(result + " added to cart!", "success",
                {
                    position: "right bottom"
                });
        }
    });
}