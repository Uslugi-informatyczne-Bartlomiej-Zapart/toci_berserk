export interface Company {
    name: string
    added: boolean
}

export type MyCompany = {
    name: string;
}

export type MyGroupCompanies = {
    [key:string]: MyCompany;
}
