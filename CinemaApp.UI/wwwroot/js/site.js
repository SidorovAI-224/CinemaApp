document.addEventListener("DOMContentLoaded", function () {
    var images = document.querySelectorAll(".openModal");
    var modals = document.querySelectorAll(".modal");
    var closeButtons = document.querySelectorAll(".close");
    var actorButtons = document.querySelectorAll(".open-actors");
    var closeActorButtons = document.querySelectorAll(".close-actors");

    images.forEach(function (img) {
        img.addEventListener("click", function () {
            var id = this.getAttribute("data-id");
            document.getElementById("modal-" + id).style.display = "flex";
        });
    });

    closeButtons.forEach(function (btn) {
        btn.addEventListener("click", function () {
            var id = this.getAttribute("data-id");
            document.getElementById("modal-" + id).style.display = "none";
        });
    });

    actorButtons.forEach(function (btn) {
        btn.addEventListener("click", function () {
            var id = this.getAttribute("data-id");
            document.querySelector(`#modal-${id} .actors-modal`).style.display = "block";
        });
    });

    closeActorButtons.forEach(function (btn) {
        btn.addEventListener("click", function () {
            this.parentElement.style.display = "none";
        });
    });

    window.addEventListener("click", function (event) {
        modals.forEach(function (modal) {
            if (event.target === modal) {
                modal.style.display = "none";
            }
        });
    });
});

function filterSessionsByDate(date) {
    let formattedDate = date.split("-").reverse().join(".");
    let rows = document.querySelectorAll("tbody tr");

    rows.forEach(row => {
        let sessionDate = row.cells[2].textContent.trim();
        if (sessionDate === formattedDate || formattedDate === "all") {
            row.style.display = "";
        } else {
            row.style.display = "none";
        }
    });
}
