$.validator.addMethod('regex', function (value, element, param) {
    return this.optional(element) || value.match(typeof param == 'string' ? new RegExp(param) : param);
}, "Input is invalid");

$.validator.addMethod('otherCostNameRequired', $.validator.methods.required, "A name is required");

$.validator.addMethod('costItemAmountRequired', $.validator.methods.required, "A valid amount is required");

$.validator.addClassRules({
    otherCostName: {
        otherCostNameRequired: true,
    },
    costItemAmount: {
        costItemAmountRequired: true,
        regex: /^[0-9]+\.*[0-9]*$/,
    },
    lenderName: {
        required: true,
    },
    loanAmount: {
        required: true,
        regex: /^[0-9]+\.*[0-9]*$/,
    },
    annualPercentageRate: {
        required: true,
        regex: /^[0-9]+\.[0-9]+$/
    },
    loanStartDate: {
        required: true,
        date: true,
    },
    termLength: {
        required: true,
        regex: /^[0-9]+$/
    },
    partnerName: {
        required: true,
    },
    cashFlowPercent: {
        required: true,
        regex: /^[0-9]+\.[0-9]+$/
    },
    appreciationPercent: {
        required: true,
        regex: /^[0-9]+\.[0-9]+$/
    },
    principalPaydownPercent: {
        required: true,
        regex: /^[0-9]+\.[0-9]+$/
    },
    taxDeductionPercent: {
        required: true,
        regex: /^[0-9]+\.[0-9]+$/
    },
    equityInvestment: {
        required: true,
        regex: /^[0-9]+\.*[0-9]*$/,
    },
    depreciationName: {
        required: true,
    },
    depreciationValue: {
        required: true,
        regex: /^[0-9]+\.*[0-9]*$/,
    },
    timeDuration: {
        required: true,
        regex: /^[0-9]+$/
    }
});

var otherCostItemIndex = 0;
var debtPartnerIndex = 0;
var equityPartnerIndex = 0;
var depreciationItemIndex = 0;

var debtPartnerValidator = $('#debtPartnersForm').validate({
    onkeyup: true,
    ignore: ".ignore"
})

var purchaseInformationValidator = $("#purchaseInformationForm").validate({
    onkeyup: true,
    ignore: ".ignore",
    rules: {
        purchasePrice: {
            required: true,
            regex: /^[0-9]+\.*[0-9]*$/
        },
        marketPrice: {
            required: true,
            regex: /^[0-9]+\.*[0-9]*$/
        },
        landValue: {
            required: true,
            regex: /^[0-9]+\.*[0-9]*$/
        },
        purchaseDate: {
            required: true,
            date: true,
        },

    },
    messages: {
        purchasePrice: {
            required: "A purchase price is required for creating a new investment",
            regex: "Field can only contain numbers"
        },
        marketPrice: {
            required: "A market price is required for creating a new investment",
            regex: "Field can only contain numbers"
        },
        landValue: {
            required: "A land value is required for creating a new investment",
            regex: "Field can only contain numbers"
        },
        purchaseDate: {
            required: "A purchase date is required",
            date: "Input date is invalid"
        },

    }
});

var propertyInformationValidator = $('#propertyInformationForm').validate({
    onkeyup: true,
    ignore: ".ignore",
    rules: {
        address: {
            required: true,
        },
        city: {
            required: true,
        },
        state: {
            required: true,
        },
        bedrooms: {
            required: true,
        },
        baths: {
            required: true,
        },
        squareFootage: {
            required: true,
        },
    },
    messages: {
        address: {
            required: "An address is required"
        },
        city: {
            required: "A city is required",
        },
        state: {
            required: "A state is required",
        },
        bedrooms: {
            required: "Enter the number of bedrooms in property"
        },
        baths: {
            required: "Enter the number of baths in property"
        },
        squareFootage: {
            required: "Enter approximate square footage of the property",
        },
    }
});

var potentialReturnValidator = $("#potentialReturnForm").validate({
    onkeyup: true,
    ignore: ".ignore",
    rules: {
        annualAppreciationRate: {
            required: true,
            regex: /^[0-9]+\.[0-9]+$/
        },
        capitalGainsTax: {
            required: true,
            regex: /^[0-9]+\.[0-9]+$/
        },
        incomeTaxRate: {
            required: true,
            regex: /^[0-9]+\.[0-9]+$/
        },
        discountRate: {
            required: true,
            regex: /^[0-9]+\.[0-9]+$/
        },
        salesCommission: {
            required: true,
            regex: /^[0-9]+\.[0-9]+$/
        },
    },
    messages: {
        annualAppreciationRate: {
            required: "An annual appreciation rate is required",
            regex: "A valid percentage is required"
        },
        capitalGainsTax: {
            required: "A capital gains tax rate is required",
            regex: "A valid percentage is required"
        },
        incomeTaxRate: {
            required: "An income tax rate is required",
            regex: "A valid percentage is required"
        },
        discountRate: {
            required: "A discount rate is required",
            regex: "A valid percentage is required"
        },
        salesCommission: {
            required: "A sales commission rate is required",
            regex: "A valid percentage is required"
        }
    }
});

function showTabIfNotShown(tab) {
    if (!$(tab).hasClass('in')) {
        $('[href="' + tab + '"]').click();
    }
}

function doPurchaseInformationValidation() {
    purchaseInformationValidator.form();
    propertyInformationValidator.form();
    if (purchaseInformationValidator.valid()) {
        $('#debtPartnersForm').validate();
        var isDebtPartnerValid = $('#debtPartnersForm').valid();
        if (isDebtPartnerValid) {
            $('#equityPartnerForm').validate();
            if ($('#equityPartnerForm').valid()) {
                $('#depreciationItemForm').validate();
                if ($('#depreciationItemForm').valid()) {
                    if (propertyInformationValidator.valid()) {
                        return true;
                    } else {
                        showTabIfNotShown('#collapseFive');
                    }
                } else {
                    showTabIfNotShown('#collapseFour');
                }
            } else {
                showTabIfNotShown('#collapseThree');
            }
        } else {
            showTabIfNotShown('#collapseTwo');
        }
    } else {
        showTabIfNotShown('#collapseOne');
    }
    return false;
}

function purchaseInformationTabNext() {
    if (doPurchaseInformationValidation()) {
        $('[href="#step2"]').tab('show');
    }
}

function doPotentialReturnValidation() {
    potentialReturnValidator.form();
    if (potentialReturnValidator.valid()) {
        return true;
    }
    return false;
}

function potentialReturnTabNext() {
    if (doPotentialReturnValidation()) {
        $('[href="#step4"]').tab('show');
    }
}

function doAllValidation() {
    if (doPurchaseInformationValidation()) {
        if (doPotentialReturnValidation()) {
            return true;
        } else {
            $('[href="#step3"]').tab('show');
        }
    } else {
        $('[href="#step1"]').tab('show');
    }
    return false;
}

function ammortizeLoan(loanAmount, years, annualPercent) {
    var monthlyPercent = annualPercent / 12.0;
    var numPayments = years * 12;
    return (monthlyPercent * loanAmount * Math.pow((1 + monthlyPercent), numPayments)) / (Math.pow(1 + monthlyPercent, numPayments) - 1);
}

function addNewInvestment() {
    // assemble debt partner class array
    var debtPartners = [];
    $('.debt-partner-row').each(function (i, obj) {
        var termLength = parseInt($(this).find('.termLength').val());
        var annualPercentageRate = parseInt($(this).find('.annualPercentageRate').val())/100.0;
        var loanAmount = parseInt($(this).find('.loanAmount').val());
        var payment = ammortizeLoan(loanAmount, termLength, annualPercentageRate);
        debtPartners.push(
            {
                LenderName: $(this).find('.lenderName').val(),
                Term: termLength,
                AnnualPercentageRate: annualPercentageRate,
                LoanStartDate: $(this).find('.loanStartDate').val(),
                LoanAmount: loanAmount,
                Payment: payment
            });
    });
    
    // assemble cost item class array
    var costItems = [];
    costItems.push({
        CostItemName: "Closing Cost",
        CostItemValue: $('#closingCost').val()
    });

    costItems.push({
        CostItemName: "Rehab Cost",
        CostItemValue: $('#rehabCost').val()
    });

    costItems.push({
        CostItemName: "Holdover Cost",
        CostItemValue: $('#holdoverCost').val()
    });

    $('.other-cost-row').each(function (i, obj) {
        costItems.push(
            {
                CostItemName: $(this).find('.otherCostName').val(),
                CostItemValue: $(this).find('.costItemAmount').val()
            });
    });

    // assemble equity partner class array
    var equityPartners = [];
    $('.equity-partner-row').each(function (i, obj) {
        equityPartners.push({
            EquityPartnerName: $(this).find('.partnerName').val(),
            CashFlowPercent: $(this).find('.cashFlowPercent').val() / 100.0,
            AppreciationPercent: $(this).find('.appreciationPercent').val() / 100.0,
            PrincipalPaydownPercent: $(this).find('.principalPaydownPercent').val() / 100.0,
            TaxDeductionPercent: $(this).find('.taxDeductionPercent').val() / 100.0,
            EquityInvestment: $(this).find('.equityInvestment').val()
        });
    });

    // assemble depreciation item class array
    var depreciationItems = [];
    $('.depreciation-item-row').each(function (i, obj) {
        depreciationItems.push({
            DepreciationItemName: $(this).find('.depreciationName').val(),
            DepreciationItemValue: $(this).find('.depreciationValue').val(),
            DepreciationItemTimeDuration: $(this).find('.timeDuration').val()
        });
    });

    // construct investment information object
    var investmentInformation = {
        // purchase info
        PurchasePrice: $('#purchasePrice').val(),
        PurchaseDate: $('#purchaseDate').val(),
        MarketPrice: $('#marketPrice').val(),
        LandValue: $('#landValue').val(),
        DownPayment: $('.downPayment').first().val(),
        TotalInvestmentCost: $('#totalInvestmentCost').val(),

        // property info
        Address: $('#address').val(),
        City: $('#city').val(),
        State: $('#state').val(),
        Bedrooms: $('#bedrooms').val(),
        Baths: $('#baths').val(),
        SquareFootage: $('#squareFootage').val(),
        PricePerSqFoot: $('#pricePerSqFoot').val(),

        // potential return info
        AnnualAppreciationRate: parseInt($('#annualAppreciationRate').val()) / 100.0,
        SalesCommission: parseInt($('#salesCommission').val()) / 100.0,
        CapitalGainsTax: parseInt($('#capitalGainsTax').val()) / 100.0,
        IncomeTaxRate: parseInt($('#incomeTaxRate').val()) / 100.0,
        DiscountRate: parseInt($('#discountRate').val()) / 100.0,

        CostItems: costItems,
        DebtPartners: debtPartners,
        EquityPartners: equityPartners,
        DepreciationItems: depreciationItems
    };

    $.ajax({
        url: '/Investments/AddInvestment',
        type: 'POST',
        dataType: 'json',
        cache: false,
        async: false,
        data: JSON.stringify(investmentInformation),
        contentType: 'application/json',
        success: function (data) {
            if (data == true) {
                success = true;
            } else alert("Failed to create new user.");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });
}


function updateDownPayment(e) {
    var totalLender = 0;
    $('.loanAmount').each(function (i, obj) {
        totalLender += parseInt($(this).val());
    });

    var totalEquityInvestment = 0;
    $('.equityInvestment').each(function (i, obj) {
        totalEquityInvestment += parseInt($(this).val());
    });

    var downPayment = parseInt($('#purchasePrice').val());
    downPayment -= totalLender;
    downPayment -= totalEquityInvestment;

    $('.downPayment').each(function (i, obj) {
        $(this).text("$" + downPayment);
    });
}


function updateTotalInvestment(e) {
    var total = parseInt($("#purchasePrice").val());
    if (!isNaN(total)) {
        $('.costItemAmount').each(function (i, obj) {
            var val = parseInt($(this).val());
            if (!isNaN(val)) {
                total += val;
            }
        });

        $('#totalInvestmentCost').text("$" + total);
    }
}


$(document).ready(function () {
    // add new debt partner list item
    $('a#addDebtPartnerLink').click(function (e) {
        //e.preventDefault();
        swal({
            title: "Add Debt Partner",
            text: '<div class="form-group text-left">\
                     <label class="inline-label" for="lenderName">Lender Name </label>\
                     <input type="text" name="debtPartnerNameInput" class="form-control" placeholder="Name">\
                   </div>\
                   <div class="form-group small-element text-left">\
                       <label class="inline-label" for="loanAmount">Loan Amount</label>\
                       <input type="text" name="loanAmountInput" class="form-control loanAmount" placeholder="$0.00"/>\
                   </div>\
                   <div class="form-group small-element text-left">\
                       <label class="inline-label" for="annualPercentage">Annual Interest</label>\
                       <input type="text" name="annualInterestInput" class="form-control annualPercentageRate" placeholder="%0.00"/>\
                   </div>\
                   <div class="form-group small-element text-left">\
                       <label class="inline-label" for="termLength">Term Length</label>\
                       <input type="text" name="termLengthInput" class="form-control termLength" placeholder="Years"/>\
                   </div>\
                   <div class="form-group text-left">\
                       <label class="inline-label" for="loanStartDate"> Loan Start Date </label>\
                       <input type="date" name="loanStartDateInput" class="form-control loanStartDate">\
                   </div>\
                   <hr/>',
            html: true,
            type: "input",
            showCancelButton: true
        }, function() {
            var tablePresent = debtPartnerIndex > 0;
            var lenderName = $('input[name=debtPartnerNameInput]').val();
            var loanAmount = numeral($('input[name=loanAmountInput]').val()).format('$0,0.00');
            var annualInterest = $('input[name=annualInterestInput]').val();
            var termLength = $('input[name=termLengthInput]').val();
            var loanStartDate = $('input[name=loanStartDateInput]').val();
            
            if (tablePresent) {
                
            } else {
                $('#addDebtPartnerLinkRow').before(
                    '\
                    <table class=\"table table-hover\">\
                        <thead>\
                            <th>Lender Name</th>\
                            <th>Loan Amount</th>\
                            <th>Annual Interest</th>\
                            <th>Term Length</th>\
                            <th>Loan Start Date</th>\
                        </thead>\
                        <tbody>\
                            <td name="debtPartnerName' + debtPartnerIndex + '">' + lenderName + '</td>\
                            <td name="loanAmount' + debtPartnerIndex + '">' + loanAmount + '</td>\
                            <td name="annualPercentageRate' + debtPartnerIndex + '">' + annualInterest + '</td>\
                            <td name="termLength' + debtPartnerIndex + '">' + termLength + '</td>\
                            <td name="loanStartDate' + debtPartnerIndex + '">' + loanStartDate + '</td>\
                            <td><button type="button" href="#" class="btn btn-danger btn-circle small-circle removeDebtElement"><i class="fa fa-times"></i></button></td>\
                        </tbody>\
                    </table>'
                    );
            }
            debtPartnerIndex++;
            //Pasted this here to get rid of NaN, now need to post in other areas
            $(document).on("change keyup paste", ".loanAmount", updateDownPayment);
            $(document).on("change keyup paste", ".equityInvestment", updateDownPayment);
            $(document).on("change", "#purchasePrice", function () {
                updateDownPayment();
                updateTotalInvestment();
            });
        });
        
        return false;
    });

    // add new equity partner list item
    $('a#addEquityPartnerLink').click(function (e) {
        e.preventDefault();
        $('#addEquityPartnerLinkRow').before('\
<div class="row equity-partner-row">\
    <div class="row nested-row">\
        <div class="form-group col-lg-4">\
            <label for="partnerName">Partner Name</label>\
            <input type="text" name="partnerName' + equityPartnerIndex + '" value="" class="form-control partnerName">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <button type="button" href="#" class="btn pull-down btn-danger btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
        </div>\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="cashFlowPercent">Cash Flow</label>\
        <input type="text" value="" name="cashFlowPercent' + equityPartnerIndex + '" class="form-control cashFlowPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="appreciationPercent">Appreciation</label>\
        <input type="text" value="" name="appreciationPercent' + equityPartnerIndex + '" class="form-control appreciationPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="principlePaydownPercent">Principle Paydown</label>\
        <input type="text" value="" name="principalPaydownPercent' + equityPartnerIndex + '" class="form-control principalPaydownPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="taxDeductionPercent">Tax Deduction</label>\
        <input type="text" value="" name="taxDeductionPercent' + equityPartnerIndex + '" class="form-control taxDeductionPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="equityInvestment">Equity Investment</label>\
        <input type="text" value="" name="equityInvestment' + equityPartnerIndex + '" class="form-control equityInvestment" placeholder="$0.00">\
    </div>\
</div>\
');
        equityPartnerIndex++;
        return false;
    });

    // add depreciation list item
    $('a#addDepreciationLink').click(function (e) {
        e.preventDefault();
        $('#addDepreciationLinkRow').before('\
<div class="row depreciation-item-row">\
    <div class="row nested-row">\
        <div class="form-group col-lg-4">\
            <label for="depreciationName">Name</label>\
            <input type="text" name="depreciationName' + depreciationItemIndex + '" value="" class="form-control depreciationName">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <button type="button" href="#" class="btn pull-down btn-danger btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
        </div>\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="depreciationValue">Value</label>\
        <input type="text" value="" name="depreciationValue' + depreciationItemIndex + '" class="form-control depreciationValue" placeholder="$0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="timeDuration">Duration</label>\
        <input type="text" value="" name="timeDuration' + depreciationItemIndex +'" class="form-control timeDuration" placeholder="">\
    </div>\
</div>\
');
        return false;
    });

    // add custom cost item
    $('a#addOtherCostLink').click(function (e) {
        e.preventDefault();
        $('#addOtherCostLinkRow').before('\
<div class="row other-cost-row">\
    <div>\
        <div class="form-group col-lg-6">\
            <label for="otherCostName">Name</label>\
            <input type="text" name="otherCostItemName' + otherCostItemIndex + '" value="" class="form-control otherCostName"></input>\
        </div>\
        <div class="form-group col-lg-4">\
            <label for="otherCostValue">Amount</label>\
            <input type="text" name="otherCostItemAmount' + otherCostItemIndex + '" value="" class="form-control costItemAmount otherCostItemAmount" placeholder="$0.00"></input>\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <a href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></a>\
        </div>\
    </div>\
</div>');
        otherCostItemIndex++;
        return false;
    });


    //add Expense Item
    $('a#addExpenseItemLink').click(function (e) {
        e.preventDefault();
        $('#addExpenseItemLinkRow').before('\
<div class="col-lg-12">\
    <div class="row">\
        <div class="form-group col-lg-4">\
            <label for ="expenseName">Name<\label>\
            <input type="text" value="" id="expenseName" class="form-control" name="expenseName">\
        </div>\
        <div class="form-group col-lg-4">\
            <label for="expenseRecurrence">Recurring<\label><input\
            <input type="checkbox" class="recurringCheckbox">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style = "min-height:42px; display:inline-block;"></span>\
            <button type="button" href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
         </div>\
        <div class="row">\
            <div class="col-lg-4" style="padding-left:4em;">\
                <a href="#" class="addExpenseItemRow">Add Expense Date Row</a>\
            </div>\
        </div>\
        <div class="col-lg-12 expenseItemValueRows">\
            <div class="form-group col-lg-2">\
                <label for="expenseDate" id = "expenseDateText" >Date</label>\
                <input type="text" value="" id="expenseDate" class="form-control" name="expenseDate" placeholder="mm/dd/yyyy">\
            </div>\
             <div class="form-group col-lg-2">\
                <label for="expenseValue" id="expenseValueText">Value</label>\
                <input type="text" value="" id="expenseValue1" class = "form-control" name="expenseValue" placeholder = "$0.00">\
            </div>\
        </div>\
    <\div>\
</div>');
        return false;

    });

    // toggle tab colors
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        $('a[data-toggle="tab"]').removeClass('btn-primary');
        $('a[data-toggle="tab"]').addClass('btn-default');
        $(this).removeClass('btn-default');
        $(this).addClass('btn-primary');
    });

    $('.next').click(function () {
        var nextId = $(this).parents('.tab-pane').next().attr("id");
        $('[href=#' + nextId + ']').tab('show');
    });

    $('.prev').click(function () {
        var prevId = $(this).parents('.tab-pane').prev().attr("id");
        $('[href=#' + prevId + ']').tab('show');
    });

    $('.submit').click(function (e) {
        e.preventDefault();
        if (doAllValidation()) {
            addNewInvestment();
        }
        return false;
    });

    $('#purchaseInformationNext').click(purchaseInformationTabNext);
    $('#potentialReturnNext').click(potentialReturnTabNext);
});

// remove an added list item field
$(document).on("click", ".removeButton", function () {
    $(this).parent().parent().parent().remove();
    updateDownPayment();
    updateTotalInvestment();
});

$(document).on("click", ".removeDebtElement", function () {
    if (debtPartnerIndex == 1) {
        $(this).parent().parent().parent().parent().remove();
    }
    else {
        $(this).parent().parent().parent().remove();
    }
    debtPartnerIndex--;
})





$(document).on("click", ".addButton", function () {
    $(this).parent().append();
});

$(document).on("click", ".expenseItemRowRemove", function () {
    $(this).parent().parent().remove();
});

//$("#plusButton").click(function () {
$(document).on("click", ".addExpenseItemRow", function () {
    //alert('add expense recurring item row');
    if ($('.addExpenseItemRow').parent().parent().parent().find('.recurringCheckbox').is(':checked')) {
        $(this).parent().parent().parent().find('.expenseItemValueRows').append('\
<div class="row expenseRecurringRow">\
    <div class="form-group col-lg-2">\
        <label for="purchaseDate">To</label>\
        <input type="text" value="" id="expensePurchaseTODate" class="form-control" name="expensePurchaseToDate" placeholder="mm/dd/yyyy">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="purchaseDate">From</label>\
        <input type="text" value="" id="expensePurchaseFromDate" class="form-control" name="expensePurchaseFromDate" placeholder="mm/dd/yyyy">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="expenseValue">Value</label>\
        <input type="text" value="" id="expenseValue" class="form-control" name="expenseValue" placeholder="$0.00">\
    </div>\
    <div class = "form-group col-lg-4">\
        <label for="expenseProrate">Prorated<\label><input\
        <input type = "checkbox" value="" id="Prorated" name = "Prorated">\
    </div>\
    <div class="form-group col-lg-1">\
        <span style = "min-height:42px; display:inline-block;"></span>\
        <a href="#" class="btn pull-down btn-default btn-circle expenseItemRowRemove"><i class="fa fa-times"></i></a>\
    </div>\
</div>');
    } else {
        $(this).parent().parent().parent().find('.expenseItemValueRows').append('\
 <div class="row col-lg-12 expenseItemValueRow">\
    <div class="form-group col-lg-2">\
        <label for="expenseDate" id = "expenseDateText" >Date</label>\
        <input type="text" value="" id="expenseDate" class="form-control" name="expenseDate" placeholder="mm/dd/yyyy">\
    </div>\
    <div class = "form-group col-lg-2">\
        <label for="expenseValue" id = "expenseValueText">Value</label>\
        <input type="text" value="" id="expenseValue1" class = "form-control" name="expenseValue" placeholder = "$0.00">\
    </div>\
    <div class="form-group col-lg-1">\
        <span style = "min-height:42px; display:inline-block;"></span>\
        <a href="#" class="btn pull-down btn-default btn-circle expenseItemRowRemove"><i class="fa fa-times"></i></a>\
    </div>\
</div>');
    }
});

$(document).on("change", ".recurringCheckbox", function () {
    var parentDiv = $(this).parent().parent().parent().parent();
    parentDiv.children('.expenseItemValueRows')[0].remove();
    if ($(this).is(':checked')) {
        parentDiv.append('\
<div class="col-lg-12 expenseItemValueRows">\
    <div class="row expenseRecurringRow">\
        <div class="form-group col-lg-2">\
            <label for="purchaseDate">To</label>\
            <input type="text" value="" id="expensePurchaseTODate" class="form-control" name="expensePurchaseToDate" placeholder="mm/dd/yyyy">\
        </div>\
        <div class="form-group col-lg-2">\
            <label for="purchaseDate">From</label>\
            <input type="text" value="" id="expensePurchaseFromDate" class="form-control" name="expensePurchaseFromDate" placeholder="mm/dd/yyyy">\
        </div>\
        <div class="form-group col-lg-2">\
            <label for="expenseValue">Value</label>\
            <input type="text" value="" id="expenseValue" class="form-control" name="expenseValue" placeholder="$0.00">\
        </div>\
        <div class = "form-group col-lg-4">\
            <label for="expenseProrate">Prorated<\label><input\
            <input type = "checkbox" value="" id="Prorated" name = "Prorated">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style = "min-height:42px; display:inline-block;"></span>\
            <a href="#" class="btn pull-down btn-default btn-circle expenseItemRowRemove"><i class="fa fa-times"></i></a>\
        </div>\
    </div>\
</div>');

    } else {

        parentDiv.append('\
<div class="col-lg-12 expenseItemValueRows">\
    <div class="form-group col-lg-2">\
        <label for="expenseDate" id = "expenseDateText" >Date</label>\
        <input type="text" value="" id="expenseDate" class="form-control" name="expenseDate" placeholder="mm/dd/yyyy">\
    </div>\
    <div class = "form-group col-lg-2">\
        <label for="expenseValue" id = "expenseValueText">Value</label>\
        <input type="text" value="" id="expenseValue1" class = "form-control" name="expenseValue" placeholder = "$0.00">\
    </div>\
</div>');

    }

});

$(document).on("keyup paste", "#purchasePrice", updateTotalInvestment);
$(document).on("change keyup paste", '.costItemAmount', updateTotalInvestment);

