$(document).ready(function () {
    $('a#addDebtPartnerLink').click(function (e) {
        e.preventDefault();
        $('#addDebtPartnerLinkRow').before('\
<div class="row">\
    <div class="form-group col-lg-4">\
        <label for="lenderName">Lender Name</label>\
        <input type="text" value="" id="lenderName" class="form-control" name="lenderName">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="annualPercentageRate">Annual Percentage Rate</label>\
        <input type="text" value="" id="annualPercentageRate" class="form-control" name="annualPercentageRate" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="loanStartDate">Loan Start Date</label>\
        <input type="date" value="" id="loanStartDate" class="form-control" name="loanStartDate">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="termLength">Term Length (months)</label>\
        <input type="text" valud="" id="termLength" class="form-control" name="termLength" placeholder="Months">\
    </div>\
    <div class="form-group col-lg-1">\
        <br />\
        <a href="#" class="btn pull-down btn-default btn-circle" type="button"><i class="fa fa-times"></i></a>\
    </div>\
</div>\
<hr />');
        return false;
    });
});