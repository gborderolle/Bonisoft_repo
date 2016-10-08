/******** Auxiliar Functions ********/

// Variable object types
var TYPES = {
    'undefined': 'undefined',
    'number': 'number',
    'boolean': 'boolean',
    'string': 'string',
    '[object Function]': 'function',
    '[object RegExp]': 'regexp',
    '[object Array]': 'array',
    '[object Date]': 'date',
    '[object Error]': 'error'
},
 TOSTRING = Object.prototype.toString;

// Get variable object type
function type(o) {
    return TYPES[typeof o] || TYPES[TOSTRING.call(o)] || (o ? 'object' : 'null');
};

function TryParseInt(str, defaultValue) {
    var retValue = defaultValue;
    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }
    }
    return retValue;
}


function TryParseFloat(str, defaultValue) {
    var retValue = defaultValue;
    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseFloat(str);
            }
        }
    }
    return retValue;
}


function show_message_confirm(msg) {
    $('#dialog p').text(hashMessages[msg]);
    $("#dialog").dialog({
        open: {},
        resizable: false,
        height: 140,
        modal: true,
        buttons: {
            "Confirmar": function () {
                $(this).dialog("close");
                return true;

            },
            "Cancelar": function () {
                $(this).dialog("close");
                return false;
            }
        }
    });
}

function show_message_info(msg) {
    $('#dialog p').text(hashMessages[msg]);
    $("#dialog").dialog({
        open: {},
        resizable: false,
        height: 140,
        modal: true,
        buttons: {
            "Aceptar": function () {
                $(this).dialog("close");
                return true;
            }
        }
    });
}

function roundUp(number, precision) {
    Math.ceil(number * precision) / precision;
}

