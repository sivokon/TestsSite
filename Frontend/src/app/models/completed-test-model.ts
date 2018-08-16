import { AnswerModel } from "./answer-model";

export interface CompletedTestModel {
    TestId: number;
    StartTime: Date;
    EndTime: Date;
    Answers: AnswerModel[];
}