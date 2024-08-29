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
}