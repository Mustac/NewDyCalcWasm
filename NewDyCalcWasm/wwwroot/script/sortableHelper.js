

//window.sortableHelper = {
//    initSortable: function (tableId, dotNetHelper) {
//        const container = document.getElementById(tableId);
//        if (container) {
//            const tbody = container.querySelector('tbody');
//            Sortable.create(tbody, {
//                swapThreshold: 0.65,
//                animation: 150,
//                onEnd: function (event) {
//                    dotNetHelper.invokeMethodAsync('UpdateMealInfo', event.oldIndex, event.newIndex);
//                },
//            });
//        }
//    }
//};

window.sortableHelper = {
    initSortable: function (tableId, dotNetHelper) {
        const container = document.getElementById(tableId);
        if (container) {
            const tbody = container.querySelector('tbody');
            if (tbody) {
                Sortable.create(tbody, {
                    swapThreshold: 0.65,
                    animation: 150,
                    onEnd: function (event) {
                        dotNetHelper.invokeMethodAsync('UpdateMealInfo', event.oldIndex, event.newIndex);
                    },
                });
            }
        }
    }
};
