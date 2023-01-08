import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { addVideo, getAllVideo, getVideoById } from './../../services/videoService';

export const addVideoAsync = createAsyncThunk('video/add', async (payload) => {
    const response = await addVideo({ url: payload.url });
    return response;
})

export const getAllVideoAsync = createAsyncThunk('video/getAll', async () => {
    const response = await getAllVideo();
    return response;
})

export const getVideoByIdAsync = createAsyncThunk('video/getById', async (payload) => {
    const response = await getVideoById({ id: payload.id });
    return response;
})

const initialState = {
    videos: [],
    currentVideo: null,
}

const videoSlice = createSlice({
    name: 'video',
    initialState,
    extraReducers: builder => {
        builder
            .addCase(addVideoAsync.fulfilled, (state, action) => {
                state.videos.push(action.payload)
            })
            .addCase(getAllVideoAsync.fulfilled, (state, action) => {
                state.videos = action.payload;
            })
            .addCase(getVideoByIdAsync.fulfilled, (state, action) => {
                state.currentVideo = action.payload;
            })
    },
});

export default videoSlice.reducer;