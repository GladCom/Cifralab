import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  userName: localStorage.getItem('userName'),
  token: localStorage.getItem('token'),
  loggedIn: false,    //  TODO: скорей всего это состояние должно быть не здесь
};

const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    loginUser: (state, action) => {
        const { userName, token } = action.payload;
        state.loggedIn = true;
        state.userName = userName;
        state.token = token;
        //  TODO: возможно где-то тут нужно сохранять данные в localStorage
    },
    logoutUser: (state) => {
        state.loggedIn = false;
        state.userName = null;
        state.token = null;
        //  TODO: возможно где-то тут нужно стирать данные из localStorage
    },
  },
});

export const { actions } = userSlice;
export default userSlice.reducer;