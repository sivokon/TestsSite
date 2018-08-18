import { AnswerModel } from "./answer-model";
import { TestModel } from "./test-model";

export interface TestStatModel {
    Id: number;
    TestId: number;
    StartTime: Date;
    EndTime: Date;
    Result: number;
    Answers: AnswerModel[];
    Test: TestModel;
}