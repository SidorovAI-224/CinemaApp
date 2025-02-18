// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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

function sortMovies(criteria) {
    let container = document.getElementById("movies-container");
    let movies = Array.from(container.getElementsByClassName("movie-item"));

    movies.sort((a, b) => {
        let valueA, valueB;

        if (criteria === "ReleaseDate") {
            valueA = new Date(a.getAttribute("data-release")).getTime(); 
            valueB = new Date(b.getAttribute("data-release")).getTime();
        } else {
            valueA = parseFloat(a.getAttribute("data-" + criteria).replace(',', '.'));
            valueB = parseFloat(b.getAttribute("data-" + criteria).replace(',', '.'));
        }

        return valueB - valueA; 
    });

    movies.forEach(movie => container.appendChild(movie)); 
}

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

function searchByTitle(inputElement) {
    let searchText = inputElement.value.trim().toLowerCase();
    let movies = document.querySelectorAll(".movie-item");
    
    movies.forEach(movie => {
        let title = movie.querySelector(".movie-title").textContent.toLowerCase();
        
        if (title.includes(searchText)) {
            movie.style.display = "block";
        } else {
            movie.style.display = "none";
        }
    });
}

document.addEventListener("DOMContentLoaded", function () {
    let buttons = document.querySelectorAll(".admin-btn");
    buttons.forEach(btn => {
        btn.addEventListener("mouseover", function () {
            this.style.transform = "scale(1.05)";
        });
        btn.addEventListener("mouseout", function () {
            this.style.transform = "scale(1)";
        });
    });
});
