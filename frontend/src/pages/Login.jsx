import React from 'react';
import { useTranslation } from 'react-i18next';

const Login = () => {
  const { t } = useTranslation();
  return (
    <div className="row justify-content-center pt-5">
      <div className="col-md-5 col-lg-4">
        <div className="premium-card p-4">
          <h2 className="h4 fw-bold mb-4 text-center">{t('login')}</h2>
          <form>
            <div className="mb-3">
              <label className="form-label small fw-bold">Email address</label>
              <input type="email" className="form-control" placeholder="name@example.com" />
            </div>
            <div className="mb-4">
              <label className="form-label small fw-bold">Password</label>
              <input type="password" className="form-control" />
            </div>
            <button type="submit" className="btn btn-primary w-100 rounded-pill py-2">Sign In</button>
          </form>
          <hr className="my-4" />
          <div className="d-grid gap-2">
            <button className="btn btn-outline-danger btn-sm rounded-pill">Continue with Google</button>
            <button className="btn btn-outline-primary btn-sm rounded-pill">Continue with Facebook</button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
