document.getElementById("uploadBtn").onchange = imageName;


function imageName() {
    document.getElementById("uploadFile").value = this.value.replace("C:\\fakepath\\", "");
}