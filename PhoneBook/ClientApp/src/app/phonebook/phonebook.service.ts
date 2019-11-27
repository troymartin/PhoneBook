import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable()
export class PhoneBookService {

    constructor(private http: HttpClient) {}
    phoneBookEndpoint =  '/api/PhoneBook/Entries';

    getPhoneBookEntries<T>() {
        return this.http.get(this.phoneBookEndpoint)
                    .toPromise()
                    .then(res => <T[]> res);
    }

    addEntry(entry: PhoneBookEntry) {
        return this.http.post(this.phoneBookEndpoint, entry)
                    .toPromise();
    }
}

export interface PhoneBookEntry {
    name: string;
    number: string;
    notes: string;
}
