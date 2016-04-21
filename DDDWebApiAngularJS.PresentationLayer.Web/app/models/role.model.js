'use strict';

function roleModel() {
    this.name = '';
    this.roleGroup = '';

    this.validateName = validateName;
    this.validateNameLength = validateNameLength;
    this.validateRoleGroup = validateRoleGroup;

    function validateName() {
        if (this.name)
            return true;

        return false;
    }

    function validateNameLength() {
        if (this.name > 3 && this.name < 60)
            return true;

        return false;
    }

    function validateRoleGroup() {
        if (this.roleGroup)
            return true;

        return false;
    }
}