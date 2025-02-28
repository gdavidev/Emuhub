/* CREATE */
export type ReportCreateRequest = {
	reported_by: number,
	content_type: string,
	content_id: number,
	reason: string,
}

/* RESOLVE */
export type ReportResolveRequest = {
	reported_by: number,
	content_type: string,
	content_id: number,
	reason: string,
	status: string,
	reviewed_by: number,
	resolution: string,
}

/* DELETE */
export type ReportDeleteRequest = {
	id: number,
}

/* GET */
export type ReportGetRequest = {
	id: number,
}
export type ReportGetResponse = {
	id: number,
	reported_by: number,
	content_type: number,
	content_type_name: string,
	content_id: number,
	reason: string,
	status: string,
	reviewed_by: number,
	resolution: string,
	created_at: number,
	updated_at: number,
}