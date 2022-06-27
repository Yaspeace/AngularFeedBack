import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FeedBackModel } from './feed-back-model';

import { MessageTheme } from './message-theme';
import { Message } from './message';
import { Contact } from './contact';
import { Observable } from 'rxjs';

@Injectable()
export class FeedBackService {
  private readonly url = "/feedback";

  constructor(private http: HttpClient) { }

  getThemes(): Observable<MessageTheme[]> {
    return this.http.get<MessageTheme[]>(this.url);
  }

  getMessage(id: number): Observable<Message> {
    return this.http.get<Message>(this.url + '/messages/' + id.toString());
  }

  getTheme(id: number): Observable<MessageTheme> {
    return this.http.get<MessageTheme>(this.url + '/themes/' + id.toString());
  }

  getContact(id: number): Observable<Contact> {
    return this.http.get<Contact>(this.url + '/contacts/' + id.toString());
  }

  sendFeedback(model: FeedBackModel): Observable<number> {
    return this.http.post<number>(this.url, model);
  }
}
