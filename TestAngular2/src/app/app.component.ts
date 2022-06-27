import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms'
import { FeedBackModel } from './feed-back-model';
import { FeedBackService } from './feed-back.service';
import { Message } from './message';
import { MessageTheme } from './message-theme';
import { HttpClient } from '@angular/common/http';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'FeedbackForm';
  feedBackForm: FormGroup;

  themes?: MessageTheme[];
  addedMessage?: Message;
  msgString?: string;

  public captchaIsLoaded = false;
  public captchaSuccess = false;
  public captchaIsExpired = false;
  public captchaResponse?: string;

  public theme: 'light' | 'dark' = 'light';
  public size: 'compact' | 'normal' = 'normal';
  public lang = 'ru';
  public type: 'image' | 'audio' = 'image';

  constructor(
    private http: HttpClient,
    private feedbackService: FeedBackService,
    private formBuilder: FormBuilder,
    private spinner: NgxSpinnerService) {
    feedbackService.getThemes().subscribe(result => {
      this.themes = result;
      this.spinner.hide();
    }, error => console.error(error));

    this.feedBackForm = this.formBuilder.group({
      "name": ["", [Validators.required, Validators.pattern("[a-z|A-Z|а-я|А-Я]*")]],
      "email": ["", [Validators.required, Validators.email]],
      "phone": ["", Validators.required],
      "theme": ["", Validators.required],
      "message": ["", Validators.required],
      recaptcha: ["", Validators.required]
    });
  }

  public submit() {
    let model = new FeedBackModel(
      this.feedBackForm.controls['name'].value,
      this.feedBackForm.controls['email'].value,
      this.feedBackForm.controls['phone'].value,
      this.feedBackForm.controls['theme'].value,
      this.feedBackForm.controls['message'].value
    );

    this.feedbackService.sendFeedback(model).subscribe(msgId => {
      this.feedbackService.getMessage(msgId).subscribe(msg => {
        this.addedMessage = msg;
        this.msgString = JSON.stringify(msg);
      }, err => console.error(err));
    },
      error => console.error(error));
  }

  ngOnInit() {
    this.spinner.show();
  }

  handleSuccess(data: any) {
    console.log(data);
  }
}
