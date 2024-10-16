import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  show: false,
  type: '',
  error: '',
  message: '',
};

const notificationSlice = createSlice({
  name: 'notification',
  initialState,
  reducers: {
    showNotification: (state, action) => {
      const { type, error, message } = action.payload;
      state.show = true;
      state.type = type;
      state.error = error;
      state.message = message;
    },
    clearNotificationData: (state) => {
      state.show = false;
      state.type = '';
      state.error = '';
      state.message = '';
    },
  },
});

export const { showNotification, clearNotificationData } = notificationSlice.actions;
export default notificationSlice.reducer;