global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using System.Security.Cryptography;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using System.ComponentModel.DataAnnotations;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using Microsoft.AspNetCore.Identity;

global using MailKit.Security;
global using MimeKit.Text;
global using MimeKit;
global using MailKit.Net.Smtp;

global using Inno_Shop.Services.Users.Application.Services.AuthService;
global using Inno_Shop.UsersMicroservice.Application.Services.EmailService;
global using Inno_Shop.UsersMicroservice.Application.Services.TokenService;
global using Inno_Shop.UsersMicroservice.Infrastucture.Data;
global using Inno_Shop.UsersMicroservice.Domain.Interfaces;
global using Inno_Shop.Services.Users.Domain.Models.Entities;
global using Inno_Shop.Services.Users.Domain.Models.Dtos;
global using Inno_Shop.Services.Users.Application.Dtos;