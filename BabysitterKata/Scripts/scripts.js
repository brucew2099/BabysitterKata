$(document).ready(function () {
    if ($('#family').length > 0) {
        $('#displayText').val("Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night");
    }

    $('#family').change(function() {
        switch ($('select#family option:selected').val()) {
        case 'A':
            $('#displayText').val("Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night");
            break;
        case 'B':
            $('#displayText')
                .val("Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night");
            break;
        case 'C':
            $('#displayText').val("Family C pays $21 per hour before 9pm, then $15 the rest of the night");
            break;
        };
    });

    $('#startTime').change(function() {
        var begin = $('select#startTime option:selected').val();

        $('#endTime option').each(function() {
            if (parseInt($(this).val()) <= parseInt(begin)) {
                $(this).prop('disabled', 'disabled');
            }
        });

        if (parseInt($('#startTime').val()) >= parseInt($('#endTime option:selected').val())) {
            $('#endTime').val(parseInt($('#startTime option:selected').val()) + 1);
        }
    });

    $('#endTime').change(function() {
        var end = $('select#endTime option:selected').val();

        $('#startTime option').each(function () {
            if (parseInt($(this).val()) >= parseInt(end)) {
                $(this).prop('disabled', 'disabled');
            }
        });

        if (parseInt($('#startTime option:selected').val()) >= parseInt($('#endTime').val())) {
            $('#startTime').val('1700');
        }
    });

    $('#calculate').click(function () {
        var calculationVm = {
            Family: $('select#family option:selected').val(),
            StartTime: $('select#startTime option:selected').val(),
            EndTime: $('select#endTime option:selected').val()
        }

        $.ajax({
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            type: 'POST',
            url: '../api/calculation',
            data: JSON.stringify(calculationVm),
            success: function(result) {
                $('#totalPay').val(result);
            }
        });
    });
});