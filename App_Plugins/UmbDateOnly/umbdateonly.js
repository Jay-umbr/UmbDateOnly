angular.module("umbraco").controller("UmbDateOnlyController", function ($scope) {
    if ($scope.model.value) {
        $scope.model.dateValue = buildDateObjectFromTime($scope.model.value);
    } 

    $scope.$watch('model.dateValue', function (newVal) {
        const date = newVal;
        $scope.model.value = extractDateForDB(newVal);
        let format = $scope.model.config.format;
        if (format == undefined) {
            format = "YYYY-MM-DD";
        }
        console.log(format);

        $scope.model.formattedDate = format.replace("YYYY", date.getFullYear()).replace("MM", date.getMonth() + 1).replace("DD", date.getDate());
        console.log($scope.model.formattedDate)
    });

    function buildDateObjectFromTime(timeObj) {
        if (!timeObj) {
            return null;
        }
    
        const { year, month, day } = timeObj
        let date = new Date();
        date.setFullYear(year);
        //-1 to month because there is a +1 offset saved in the DB
        date.setMonth(month-1);
        date.setDate(day);
        return new Date(date.toISOString().split("T")[0]);
    }

    $scope.useTodaysDate = function () {
        $scope.model.dateValue = new Date();
    }

    function extractDateForDB(date) {
        if (!(date instanceof Date)) {
            return null;
        }
        //+1 to Month because in C# months are 1-based and in JS they are 0-based
        return time = {
            year: date.getFullYear(),
            month: date.getMonth()+1,
            day: date.getDate()
        }
    }
})