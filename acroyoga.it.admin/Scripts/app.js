$(document).ready(function () {
    $('.datepicker').datepicker();

});
tinymce.init({
    selector: 'textarea',
    plugins: "image,autoresize,link,media,emoticons,hr,link lists,textcolor colorpicker,table,code",
    toolbar: ["undo redo | bold italic underline | alignleft aligncenter alignright alignjustify | forecolor backcolor fontsizeselect",
    "bullist numlist outdent indent | table | code | link image media emoticons"],
    image_prepend_url: "http://acroyoga.azurewebsites.net/"
});