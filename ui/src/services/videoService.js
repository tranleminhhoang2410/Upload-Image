import axios from '../api/axios';

const END_POINTS = {
    GET_VIDEO: '/Video',
    ADD_VIDEO: 'Video/addVideo',
}

export const addVideo = (data) => axios.post(END_POINTS.ADD_VIDEO, data);

export const getAllVideo = () => axios.get(END_POINTS.GET_VIDEO);

export const getVideoById = (id) => axios.get(`${END_POINTS.GET_VIDEO}/${id}`);

