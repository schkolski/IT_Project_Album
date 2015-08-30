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

    $("#txbNewOfferDescription").keydown(function (e) {       
        
        if ($(this).val().length >= 220) {  
            if (e.keyCode >= 37 && e.keyCode <= 40) {
                return; // arrow keys
            }
            if (e.keyCode === 8 || e.keyCode === 46) {
                return; // backspace (8) / delete (46)
            }
            e.preventDefault();
        }
    });

    $(document).on('keydown', '#txbNewOfferAlbum', function () {
        $(this).css({ 'background-color': '#fff', 'color': '#000' });
    }); 

    $(document).on('keydown', '#txbNewOfferAlbumYear', function () {
        $(this).css({ 'background-color': '#fff', 'color': '#000' });
    });

    $(document).on('keydown', '#txbNewOfferID', function () {
        $(this).css({ 'background-color': '#fff', 'color': '#000' });
     });

    $(document).on('keydown', '#txbNewOfferNumber', function () {
        $(this).css({ 'background-color': '#fff', 'color': '#000' });
     });

     $(document).on('keydown', '#txbNewOfferPrice', function () {
         $(this).css({ 'background-color': '#fff', 'color': '#000' });
     });
   
});