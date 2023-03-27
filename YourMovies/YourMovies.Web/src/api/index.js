import axios from "axios";

export const BaseUrl = 'https://localhost:7227/api/';

export const EndPoints = {
    ganre: 'Ganre/'
}

export const EndPointsGanre = {
    getAll: 'Ganre/GetGanre/',
    getById: 'Ganre/GetGanre/',
    create: 'Ganre/AddGanre',
    delete: 'Ganre/DeleteGanre/',
    update: 'Ganre/UpdateGanre',
}

export const EndPointsCountry = {
    getAll: 'Country/GetCountry/',
    getById: 'Country/GetCountry/',
    create: 'Country/AddCountry',
    delete: 'Country/DeleteCountry/',
    update: 'Country/UpdateCountry',
}

export const EndPointsTypeCinema = {
    getAll: 'TypeCinema/GetTypeCinema/',
    getById: 'TypeCinema/GetTypeCinema/',
    create: 'TypeCinema/AddTypeCinema',
    delete: 'TypeCinema/DeleteTypeCinema/',
    update: 'TypeCinema/UpdateTypeCinema',
}

export const EndPointsPerson = {
    getAll: 'Person/GetPerson/',
    getById: 'Person/GetPerson/',
    create: 'Person/AddPerson',
    delete: 'Person/DeletePerson/',
    update: 'Person/UpdatePerson',
}

export const EndPointsProductionCompany = {
    getAll: 'ProductionCompany/GetProductionCompany/',
    getById: 'ProductionCompany/GetProductionCompany/',
    create: 'ProductionCompany/AddProductionCompany',
    delete: 'ProductionCompany/DeleteProductionCompany/',
    update: 'ProductionCompany/UpdateProductionCompany',
}

export const EndPointsDepartment = {
    getAll: 'Department/GetDepartment/',
    getById: 'Department/GetDepartment/',
    create: 'Department/AddDepartment',
    delete: 'Department/DeleteDepartment/',
    update: 'Department/UpdateDepartment',
}

export const EndPointsAgeRating = {
    getAll: 'AgeRating/GetAgeRating/',
    getById: 'AgeRating/GetAgeRating/',
    create: 'AgeRating/AddAgeRating',
    delete: 'AgeRating/DeleteAgeRating/',
    update: 'AgeRating/UpdateAgeRating',
}

export const EndPointsCinemaCast = {
    getAll: 'CinemaCast/GetCinemaCast/',
    getById: 'CinemaCast/GetCinemaCast/',
    create: 'CinemaCast/AddCinemaCast',
    delete: 'CinemaCast/DeleteCinemaCast/',
    update: 'CinemaCast/UpdateCinemaCast',
}

export const EndPointsCinemaCrew = {
    getAll: 'CinemaCrew/GetCinemaCrew/',
    getById: 'CinemaCrew/GetCinemaCrew/',
    create: 'CinemaCrew/AddCinemaCrew',
    delete: 'CinemaCrew/DeleteCinemaCrew/',
    update: 'CinemaCrew/UpdateCinemaCrew',
}

export const EndPointsCinema = {
    getAll: 'Cinema/GetCinema/',
    getById: 'Cinema/GetCinema/',
    create: 'Cinema/AddCinema',
    delete: 'Cinema/DeleteCinema/',
    update: 'Cinema/UpdateCinema',
}

export const createApiEndpoint = endpoint => {
    let url = BaseUrl + endpoint;
    return {
        fetch: () => axios.get(url),
        fetchById: id => axios.get(url + id),
        create: newRecord => axios.post(url, newRecord),
        update: (updatedRecord) => axios.put(url, updatedRecord),
        delete: id => axios.delete(url + id),
    }
}
