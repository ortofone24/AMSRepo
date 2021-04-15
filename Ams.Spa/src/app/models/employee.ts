export interface Employee {
    empNo: number;
    birthDate: Date;
    firstName: string;
    lastName: string;
    gender: string;
    hireDate: Date;
    salary: number;
    title: string;
}
export interface RootObjectEmployee {
    pageNumber: number;
    pageSize: number;
    firstPage: string;
    lastPage: string;
    totalPages: number;
    totalRecords: number;
    nextPage: string;
    previousPage?: any;
    data: Employee[];
    succeeded: boolean;
    errors?: any;
    message?: any;
}

export interface RootObject {
    data: Employee;
    succeeded: boolean;
    errors?: any;
    message: string;
}