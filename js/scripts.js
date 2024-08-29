function initializeCounterComponent() {
    let nameInput = document.getElementById("name-input");
    if (nameInput) {
        nameInput.addEventListener("keydown", (e) => {
            if(e.key !== "Enter") {
                e.stopPropagation();
                e.stopImmediatePropagation();
            }
        });
    }
    let allImages = document.getElementsByTagName("img");
    for (let i = 0; i < allImages.length; i++) {
        allImages[i].addEventListener("dragstart", (e) => {
            console.log("Image clicked");
            return false;
        });
    }
}