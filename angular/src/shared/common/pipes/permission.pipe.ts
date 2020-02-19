﻿import { Injector, Pipe, PipeTransform } from '@angular/core';
import { PermissionCheckerService } from '@abp/auth/permission-checker.service';

@Pipe({
    name: 'permission'
})
export class PermissionPipe implements PipeTransform {

    permission: PermissionCheckerService;

    constructor(injector: Injector) {
        this.permission = injector.get(PermissionCheckerService);
    }

    transform(permission: string): boolean {
        return this.permission.isGranted(permission);
    }
}
