import { Component, OnInit } from '@angular/core';
import { PhoneBookEntry, PhoneBookService } from './phonebook.service';

@Component({
  selector: 'app-phonebook-component',
  templateUrl: './phonebook.component.html'
})
export class PhoneBookComponent implements OnInit {

  entries: PhoneBookEntry[];
  entries2: PhoneBookEntry[];
  entry: PhoneBookEntry = {name: '', number: '', notes: ''};
  cols: any[];
  clonedEntries: { [s: string]: PhoneBookEntry; } = {};

  constructor(private phoneBookService: PhoneBookService) { }

    ngOnInit() {
        this.phoneBookService.getPhoneBookEntries<PhoneBookEntry>().then(entries => this.entries = entries);
        this.cols = [
          { field: 'name', header: 'Name' },
          { field: 'number', header: 'Number' },
          { field: 'notes', header: 'Notes' }
      ];
    }

    addEntry() {
    this.phoneBookService.addEntry(this.entry)
      .then(res => this.phoneBookService.getPhoneBookEntries<PhoneBookEntry>())
      .then(entries => this.entries = entries);
    }

    onRowEditInit(entry: PhoneBookEntry) {
      this.clonedEntries[entry.number] = {...entry};
  }

  onRowEditSave(entry: PhoneBookEntry) {
      if (entry.name.length > 0) {
          delete this.clonedEntries[entry.number];
  }
}

  onRowEditCancel(entry: PhoneBookEntry, index: number) {
      this.entries2[index] = this.clonedEntries[entry.number];
      delete this.clonedEntries[entry.number];
  }
}
