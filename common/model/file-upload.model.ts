export class FileUpload {
    constructor() {
        this.id = 0;
        this.blob = "";
        this.fileName = ""
        this.size = 0;
        this.email= "";
    }
    id: number;
    blob: string;
    fileName: string;
    filePath :any;
    size: number;
    email: string;
}


export enum ProgressStatusEnum {
    START, COMPLETE, IN_PROGRESS, ERROR
  }
