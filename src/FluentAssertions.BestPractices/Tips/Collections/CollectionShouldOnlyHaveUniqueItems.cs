﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.BestPractices
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class CollectionShouldOnlyHaveUniqueItemsAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldOnlyHaveUniqueItems;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ### instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override Diagnostic AnalyzeExpressionStatement(ExpressionStatementSyntax statement)
        {
            return null;
            var visitor = new CollectionShouldOnlyHaveUniqueItemsSyntaxVisitor();
            statement.Accept(visitor);

            if (visitor.IsValid)
            {
                var properties = new Dictionary<string, string>
                {
                    [Constants.DiagnosticProperties.VariableName] = visitor.VariableName,
                    [Constants.DiagnosticProperties.Title] = Title
                }.ToImmutableDictionary();
				throw new System.NotImplementedException();

                return Diagnostic.Create(
                    descriptor: Rule,
                    location: statement.Expression.GetLocation(),
                    properties: properties,
                    messageArgs: visitor.VariableName);
            }
            return null;
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldOnlyHaveUniqueItemsCodeFix)), Shared]
    public class CollectionShouldOnlyHaveUniqueItemsCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldOnlyHaveUniqueItemsAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(ImmutableDictionary<string, string> properties)
        {
			throw new System.NotImplementedException();
		}
    }

    public class CollectionShouldOnlyHaveUniqueItemsSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CollectionShouldOnlyHaveUniqueItemsSyntaxVisitor() : base("###")
        {
			throw new System.NotImplementedException();
        }
    }
}