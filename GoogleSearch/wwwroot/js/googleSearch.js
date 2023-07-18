$(document).ready(function () {
    // Handle keyup events on the search input
    $("#searchInput").on("keyup", function() {
        // Get the search term
        var searchTerm = $("#searchInput").val();

        // Make an Ajax request to the Umbraco API
        $.ajax({
            url: "/umbraco/api/googlesearch/GetData?search=" + searchTerm,
            data: {
                searchTerm: searchTerm
            },
            success: function(data) {
                // Clear the search results list
                $("#searchResults").empty();

                // Loop through the search results and add them to the list
                for (var i = 0; i < data.length; i++) {
                    var result = data[i];

                    // Create a new list item
                    var li = $("<li>");

                    // Add the title to the list item
                    /*li.append(result.title);*/
                    li.append("<a href='#'>" + result.title + "</a>");
                    li.append("<p class='searchBody'>" + result.body + "</p>");

                    // Add the list item to the list
                    $("#searchResults").append(li);
                }
            }
        });
    });
});