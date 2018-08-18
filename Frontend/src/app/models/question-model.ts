import { OptionModel } from "./option-model";

export interface QuestionModel {
    Id: number;
    Body: string;
    Index: number;
    TestId: number;
    Options: OptionModel;
}