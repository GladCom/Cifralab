import { createSlice } from '@reduxjs/toolkit';

const { loggedIn } = JSON.parse(sessionStorage.getItem('loggedIn')) ?? { loggedIn: false }; //  TODO: удалить потом!

const initialState = {
  userName: localStorage.getItem('userName'),
  token: localStorage.getItem('token'),
  loggedIn, //  TODO: скорей всего это состояние должно быть не здесь
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

      sessionStorage.setItem('loggedIn', JSON.stringify({ loggedIn: true }));
    },
    logoutUser: (state) => {
      state.loggedIn = false;
      state.userName = null;
      state.token = null;

      sessionStorage.setItem('loggedIn', JSON.stringify({ loggedIn: false }));
    },
  },
});

export const { actions } = userSlice;
export default userSlice.reducer;
