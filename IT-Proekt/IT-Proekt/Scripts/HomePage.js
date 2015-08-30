$(document).ready(function () {
    $("#toggleAdvancedSearch").click(function () {
        $("#advancedSearchContainer").slideToggle(700);
    });

    $("#btnNewOffer").click(function () {
        $("#newOfferContainer").slideToggle(700);
    });

    $("#imageUpload").change(function () {
        var preview = document.querySelector('#imagePreview');
        var file = document.querySelector('#imageUpload').files[0];
        var reader = new FileReader();

        reader.onloadend = function () {
            preview.src = reader.result;
        }

        if (file) {
            reader.readAsDataURL(file);
        } else {
            preview.src = "";
        }
    });

    
});