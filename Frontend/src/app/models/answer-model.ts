import { AnswerOption } from "./answer-option";

export interface AnswerModel {
    QuestionId: number;
    AnswerOptions: AnswerOption[];
    PointValue: number;
}