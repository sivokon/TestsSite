import { AnswerModel } from "./answer-model";

export interface CompletedTestModel {
    TestId: number;
    Answers: AnswerModel[];
}