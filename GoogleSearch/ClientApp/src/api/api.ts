import axios, { AxiosError } from 'axios';
import * as requests from '../interfaces/IRequest';

const api = axios.create({
    baseURL: window.location.origin + "/api",
    //timeout: 50000,
});

//Pesquise o texto no google e retorna a resposta e paginação
export async function SearchGoogle(searchValue: string, nextPage?: string) {
    const params = { searchValue, nextPage };
    const result: requests.ISearchGoogle = await api.get(`Search/Google`, { params }).then(response => response.data).catch((err: AxiosError) => err);
    return result;
}
