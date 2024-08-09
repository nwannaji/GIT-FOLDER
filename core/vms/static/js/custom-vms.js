// creates a search box for visitors and for scrolling vertically
document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("searchInput").addEventListener("keyup", function() {
        const searchText = this.value.toLowerCase();
        const rows = document.getElementById("tableBody").getElementsByTagName("tr");
        Array.from(rows).forEach(function(row) {
            const cells = row.getElementsByTagName("td");
            let found = false;
            Array.from(cells).forEach(function(cell) {
                const text = cell.textContent.toLowerCase();
                if (text.includes(searchText)) {
                    found = true;
                }
            });
            if (found) {
                row.style.display = "";
            } else {
                row.style.display = "none";
            }
        });
    });
});


// creates a search box for visitors and for scrolling vertically
document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("employeeSearchInput").addEventListener("keyup", function() {
        const searchText = this.value.toLowerCase();
        const rows = document.getElementById("employeeTableBody").getElementsByTagName("tr");
        Array.from(rows).forEach(function(row) {
            const cells = row.getElementsByTagName("td");
            let found = false;
            Array.from(cells).forEach(function(cell) {
                const text = cell.textContent.toLowerCase();
                if (text.includes(searchText)) {
                    found = true;
                }
            });
            if (found) {
                row.style.display = "";
            } else {
                row.style.display = "none";
            }
        });
    });
});

// 
document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("visitorSearchInput").addEventListener("keyup", function() {
        const searchText = this.value.toLowerCase();
        const rows = document.getElementById("visitorTableBody").getElementsByTagName("tr");
        Array.from(rows).forEach(function(row) {
            const cells = row.getElementsByTagName("td");
            let found = false;
            Array.from(cells).forEach(function(cell) {
                const text = cell.textContent.toLowerCase();
                if (text.includes(searchText)) {
                    found = true;
                }
            });
            if (found) {
                row.style.display = "";
            } else {
                row.style.display = "none";
            }
        });
    });
});
