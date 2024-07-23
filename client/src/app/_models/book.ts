export interface Book {
    id: number;
    author: string;
    title: string;
    description: string;
    coverImage: string;
    publisher: string;
    publicationDate: number;
    categoryId: number;
    pageCount: number;
    checkedOutUser: number;
    checkedOutUntil: Date;
    rating: number;
}


