

const app = {
    init: function () {
        this.bindEvents();
        this.modal = document.getElementById("meal-modal");
    },

    bindEvents: function() {
        document.getElementById("search-button").addEventListener("click", () => this.getMealList());
        document.getElementById("results").addEventListener("click", (e) => this.getMealRecipe(e));
        document.getElementById("close-modal").addEventListener("click", () => this.closeModal());
        document.getElementById("ingredient-input").addEventListener("keypress", 
            (e) => this.handleEnterPress(e));
        window.addEventListener("click", (event) => this.windowOnClick(event));
    },

    handleEnterPress: function(e) {
        if (e.key === "Enter") {
            this.getMealList();
        }
    },

    getMealList: function () {
        let searchInputTxt = document.getElementById("ingredient-input").value.trim();
        fetch(`?action=search&keyword=${searchInputTxt}`)
        .then(response => response.json())
        .then(data => this.displayMeals(data.meals))
        .catch(err => console.error(err));
    },

    displayMeals: function (meals) {
        const results = document.getElementById("results");
        let html = "";

        if (meals) {
            meals.forEach(meal => {
                html += `
                    <div class="meal-item" data-id="${meal.idMeal}">
                        <img src="${meal.strMealThumb}" alt="Meal image">
                        <div class="meal-info">
                            <h3>${meal.strMeal}</h3>
                        </div>
                    </div>
                `;
            });
        } else {
            html = "<p>Niestety baza nie ma danych dla podanego słowa.</p>";
        }

        results.innerHTML = html;
    },

    getMealRecipe: function (e) {
        e.preventDefault();

        if (e.target.parentElement.classList.contains("meal-item")) {
            const mealID = e.target.parentElement.getAttribute("data-id");

            fetch(`?action=getRecipe&id=${mealID}`)
            .then(response => response.json())
            .then(data => this.displayMealRecipe(data.meals[0]))
            .catch(err => console.error(err)); 
        }
    },

    displayMealRecipe: function (meal) {
        console.log("displayMealRecipe:", meal);
        const modalContent = document.getElementById("modal-content");
        let html = `
            <h2>${meal.strMeal}</h2>
            <h4>${meal.strCategory}</h4>
            <div>
                <img src="${meal.strMealThumb}">
                <p>${meal.strInstructions}</p>
            </div>
        `;

        modalContent.innerHTML = html;
        this.showModal();
    },

    showModal: function () {
        this.modal.style.display = "block";
    },
    
    closeModal: function () {
        this.modal.style.display = "none";
    },

    windowOnClick: function (event) {
        if (event.target === this.modal) {
            this.closeModal();
        }
    }
};

app.init();