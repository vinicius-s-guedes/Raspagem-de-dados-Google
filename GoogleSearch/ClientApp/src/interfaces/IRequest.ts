
export interface ISearchGoogle {
    items: IItem[]
    paginations: IPage[]
}

export interface IItem {
    title: string
    link: string
}
export interface IPage {
    page: string
    link: string
}