import { configureStore } from "@reduxjs/toolkit"
import videoReducer from "../features/video/videoSlice"

const rootReducer = {
    video: videoReducer,
}

const store = configureStore({
    reducer: rootReducer,
})

export default store;