import { AnswerModel } from "./answer-model";

export interface TestStatModel {
    Id: number;
    TestId: number;
    StartTime: Date;
    EndTime: Date;
    Result: number;
    Answers: AnswerModel[];
}