window.sortableHelper = {
    initSortable: function (tableId, dotnetHelper) {
        const container = document.getElementById(tableId);
        const tbody = container.querySelector('table tbody');

        Sortable.create(tbody, {
            swapThreshold: 0.65,
            animation: 150,
            onStart: function (event) {
                event.item.dataset.orderId = event.item.id;
            },
            onEnd: function (event) {
                dotnetHelper.invokeMethodAsync('UpdateMealInfo', event.oldIndex, event.newIndex);
            },
        });
    },
};

// sortableHelper.js
(function () {
    // Your existing code

    window.test = () => {
        console.log("Test function called");
    };
})();